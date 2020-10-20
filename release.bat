@echo on
set versionnumber=0.7
md release%versionnumber%
cd release%versionnumber%
md GameData
md GameData\KSRSS
cd ..
xcopy /s KSRSS release%versionnumber%\GameData\KSRSS
SET ZIP="C:\Program Files\7-Zip\7z.exe"
%ZIP% a KSRSS-%versionnumber%.zip -tzip -r .\release%versionnumber%\GameData
rd /s /q release%versionnumber%