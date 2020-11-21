/*  Copyright (c) 2019-2020 blowfish
    Copyright (c) 2020 KSRSS Team
    This file is part of KSRSS.dll.

    KSRSS.dll is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    KSRSS.dll is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with KSRSS.dll.  If not, see <https://www.gnu.org/licenses/>.
*/
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Blacklist : MonoBehaviour
    {
        private readonly string[] COMMENT_SEPARATOR = { "//" };
        UrlDir gameData = GameDatabase.Instance.root.children.Find(dir => dir.type == UrlDir.DirectoryType.GameData);
        private void Start()
        {
            ConfigNode settings = GameDatabase.Instance.GetConfigNodes("KSRSSSETTINGS")[0];
            Settings.textureRes = settings.GetValue("textureRes");
            HashSet<UrlDir.UrlFile> blacklist = new HashSet<UrlDir.UrlFile>();
            string res = Settings.textureRes;
            Debug.Log("[KSRSS] Loading " + res + " blacklist");
            string[] assets =
                File.ReadAllLines(KSPUtil.ApplicationRootPath + "GameData/KSRSS/blacklists/" + res + ".blacklist");
            foreach (UrlDir.UrlFile blacklistFile in FindFilesInAssetListFile(assets, gameData))
            {
                blacklist.Add(blacklistFile);
            }
            
            // VE Textures
            Settings.textureVERes = settings.GetValue("textureVERes");
            string VEres = Settings.textureVERes + "VE";
            Debug.Log("[KSRSS] Loading " + VEres + " blacklist");
            string[] VEassets = 
                File.ReadAllLines(KSPUtil.ApplicationRootPath + "GameData/KSRSS/blacklists/" + VEres +".blacklist");
            foreach (UrlDir.UrlFile blacklistFile in FindFilesInAssetListFile(VEassets, gameData))
            {
                blacklist.Add(blacklistFile);
            }
            Debug.Log("[KSRSS] Removing blacklisted assets");
            foreach (UrlDir.UrlFile file in blacklist)
            {
                Debug.Log($"[KSRSS] Removing {file.url}.{file.fileExtension}");
                UrlDir.UrlFile newFile2 = new UrlDir.UrlFile(file.parent, new FileInfo(file.fullPath + ".disabled"));
                file.parent.files[file.parent.files.IndexOf(file)] = newFile2;
            }
            Destroy(gameObject);
        }
        private IEnumerable<UrlDir.UrlFile> FindFilesInAssetListFile(string[] lines, UrlDir dir)
        {
            foreach (string line in lines)
            {
                string lineBeforeComment = line.Split(COMMENT_SEPARATOR, 2, StringSplitOptions.None)[0].Trim();
                if (lineBeforeComment == string.Empty) continue;

                bool matchedFile = false;
                foreach (UrlDir.UrlFile urlFile in FindFilesForUrl(lineBeforeComment, dir))
                {
                    yield return urlFile;
                    matchedFile = true;
                }

                if (!matchedFile)
                    Debug.LogError($"[KSRSS] No files found matching url {lineBeforeComment}");
            }
        }

        private readonly char[] PATH_SEPARATOR = new[] { '/' };
        private IEnumerable<UrlDir.UrlFile> FindFilesForUrl(string url, UrlDir dir)
        {
            string[] splits = url.Split(PATH_SEPARATOR, 2);

            if (splits.Length == 1)
            {
                if (splits[0] == string.Empty)
                {
                    foreach (UrlDir.UrlFile file in dir.files)
                    {
                        if (file.fileType == UrlDir.FileType.Config) continue;
                        yield return file;
                    }

                    // Already excludes configs
                    foreach (UrlDir.UrlFile file in dir.AllFiles)
                    {
                        yield return file;
                    }
                }
                else
                {
                    int idx = splits[0].LastIndexOf('.');
                    string fileName;
                    string fileExtension;

                    if (idx != -1)
                    {
                        fileName = splits[0].Substring(0, idx);
                        fileExtension = splits[0].Substring(idx + 1);
                    }
                    else
                    {
                        fileName = splits[0];
                        fileExtension = null;
                    }

                    string pattern = '^' + Regex.Escape(fileName).Replace(@"\*", ".*") + '$';
                    Regex regex = new Regex(pattern);

                    foreach (UrlDir.UrlFile file in dir.files)
                    {
                        if (file.fileType == UrlDir.FileType.Config) continue;
                        if (!regex.IsMatch(file.name)) continue;
                        if (fileExtension != null && fileExtension != file.fileExtension) continue;
                        yield return file;
                    }
                }
            }
            else if (splits.Length == 2)
            {
                string pattern = '^' + Regex.Escape(splits[0]).Replace(@"\*", ".*") + '$';
                Regex regex = new Regex(pattern);

                foreach (UrlDir subDir in dir.children)
                {
                    if (regex.IsMatch(subDir.name))
                    {
                        foreach (UrlDir.UrlFile file in FindFilesForUrl(splits[1], subDir))
                        {
                            yield return file;
                        }
                    }
                }
            }
            else
            {
                throw new NotImplementedException("This code should never be reached");
            }
        }
    }
}