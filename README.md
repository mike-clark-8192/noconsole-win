# noconsole-win

Launch console programs without console windows (on Windows).

This solution builds two .NET Framework executables. Both executables have the same usage format:

`noconsolec.exe <commandline>`

`noconsolew.exe <commandline>`

They are both built without the console subsystem, so they themselves will not display a console window when run.

## noconsolec
noconsolec uses win32's CreateProcess to create a new process with the commandline specified, prefixed with:
```
%windir%\system32\cmd.exe /c
```
The new process is created with the `CREATE_NO_WINDOW` flag. This may be useful for hiding a console window when running a console application. The stdout/stderr of the new process could be redirected using cmd.exe's redirection syntax.

## noconsolew
noconsolew uses win32's CreateProcess to create a new process with the commandline specified. The new process is created with the `CREATE_NO_WINDOW` flag. This may be useful for hiding a console window when running a console application. The stdout/stderr of the new process will be lost.

## common behavior
Both executables will use win32's MessageBox to display detected errors.
