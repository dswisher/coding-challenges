
# Compile the solution, if out of date

$maxLen = 80

if (!(Test-Path "solution.cs"))
{
    Write-Host "solution.cs does not seem to exist!"
    return;
}

# TODO - check dates on both files, and only compile if out-of-date
Write-Host "...compiling..."
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo solution.cs

if(-not $?)
{
    Write-Host "Compilation FAILED!"
    return;
}

# Run some tests
Get-ChildItem "." -Filter input*.txt | 
Foreach-Object {
    $testName = $_.Name
    $inFile = $_.Name
    $outFile = $inFile -replace "input", "output"
    $tempFile = "../temp/" + $outFile
    
    Get-Content $inFile | solution.exe > $tempFile
    
    $expected = Get-Content $outFile
    $actual = Get-Content $tempFile
    
    if ($expected -ne $actual)
    {
        if ($expected.Length -gt $maxLen) { $expected = $expected.SubString(0, $maxLen) + "..."; }
        if ($actual.Length -gt $maxLen) { $actual = $actual.SubString(0, $maxLen) + "..."; }

        Write-Host "Test" $testName "FAILED!"
        Write-Host "   Expected:" $expected
        Write-Host "     Actual:" $actual
    }
    else
    {
        Write-Host "Test" $testName "passed!"
    }
    
    #Write-Host "Expected" $expected
    #Write-Host "Actual" $actual
    
    # if (compare-object (get-content one.txt) (get-content two.txt))
    # if ((Get-FileHash $outFile).hash -ne (Get-FileHash $tempFile).hash)
    #if (@(Compare-Object 
    #    $(Get-Content $outFile -encoding byte) 
    #    $(Get-Content $tempFile -encoding byte) 
    #    -sync 0).length -eq 0)
    #{
    #    Write-Host "Test" $inFile "FAILED!"
    #}
    #else
    #{
    #    Write-Host "Test" $inFile "passed!"
    #}
    
}
