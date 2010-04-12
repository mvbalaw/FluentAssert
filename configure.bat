@ECHO OFF

REM project: Configure http://github.com/handcraftsman/Configure
REM author: Copyright (c) 2010 Clinton Sheppard <gar3ts@gmail.com>
REM license: MIT License http://creativecommons.org/licenses/MIT/

SETLOCAL
SET CONFIGURE_RAW_FILE_URL=http://github.com/handcraftsman/Configure/raw/master/
SET CONFIGURE_SCRIPT_FILE_NAME=configure.js
SET CONFIGURE_SCRIPT_URL="%CONFIGURE_RAW_FILE_URL%%CONFIGURE_SCRIPT_FILE_NAME%"
SET DOWNLOAD_SCRIPT_FILE_NAME=downloadFile.js

cscript > NUL
IF ERRORLEVEL 1 GOTO:CSCRIPT_FAILED

IF EXIST %CONFIGURE_SCRIPT_FILE_NAME% GOTO :CONFIGURE
IF EXIST %DOWNLOAD_SCRIPT_FILE_NAME% GOTO :DOWNLOAD_CONFIGURE_SCRIPT

(ECHO function downloadFile(url, fileName^)
ECHO {
ECHO     var result;
ECHO     try
ECHO     {
ECHO         var req = new ActiveXObject("WinHttp.WinHttpRequest.5.1"^);
ECHO         req.Open("GET", url, false^);
ECHO         req.Send(^);
ECHO         var ForWriting= 2;
ECHO         var AsAscii = 0;
ECHO         var fso = new ActiveXObject("Scripting.FileSystemObject"^);
ECHO         var file = fso.OpenTextFile(fileName, ForWriting, true, AsAscii^);
ECHO         file.Write(req.ResponseText^);
ECHO         file.Close(^);
ECHO         result = "OK\n"+file.path;
ECHO     }
ECHO     catch (error^)
ECHO     {
ECHO         result = error + "\n"
ECHO         result += "WinHTTP returned error: " + 
ECHO             (error.number ^& 0xFFFF^).toString(^) + "\n\n";
ECHO         result += error.description;
ECHO     }
ECHO     return result;
ECHO }
ECHO downloadFile(WScript.Arguments.Item(0^),WScript.Arguments.Item(1^)^);) >> %DOWNLOAD_SCRIPT_FILE_NAME%

:DOWNLOAD_CONFIGURE_SCRIPT

IF EXIST %CONFIGURE_SCRIPT_FILE_NAME% GOTO :CONFIGURE
ECHO downloading %CONFIGURE_SCRIPT_URL% to %CONFIGURE_SCRIPT_FILE_NAME%

cscript //NoLogo %DOWNLOAD_SCRIPT_FILE_NAME% "%CONFIGURE_SCRIPT_URL%" "%CONFIGURE_SCRIPT_FILE_NAME%" > NUL

IF NOT EXIST %CONFIGURE_SCRIPT_FILE_NAME% GOTO:DOWNLOAD_CONFIGURE_SCRIPT_FAILED

:CONFIGURE

ECHO executing %CONFIGURE_SCRIPT_FILE_NAME%

cscript //NoLogo %CONFIGURE_SCRIPT_FILE_NAME%

IF ERRORLEVEL 1 GOTO:CONFIGURE_FAILED

ECHO configuration complete type Build.bat to build

IF EXIST %DOWNLOAD_SCRIPT_FILE_NAME% del %DOWNLOAD_SCRIPT_FILE_NAME%
IF EXIST %CONFIGURE_SCRIPT_FILE_NAME% del %CONFIGURE_SCRIPT_FILE_NAME%

GOTO :EOF

:DOWNLOAD_CONFIGURE_SCRIPT_FAILED
ECHO failed to download %CONFIGURE_SCRIPT_URL% to %CONFIGURE_SCRIPT_FILE_NAME% ... please download the file manually and rerun configure.bat
GOTO :EOF

:CONFIGURE_FAILED
ECHO CONFIGURE failed, see error message above... cannot continue.
GOTO :EOF

:CSCRIPT_FAILED
ECHO cscript engine disabled or missing... cannot continue.
GOTO :EOF