# Source: https://gist.github.com/JonCanning/a083e80c53eb68fac32fe1bfe8e63c48
$regex = [regex] 'PackageReference Include="([^"]*)" Version="([^"]*)"'
ForEach ($file in get-childitem . -recurse | where {$_.extension -like "*proj"})
{
  $proj = $file.fullname
  $content = Get-Content $proj
  $match = $regex.Match($content)
  if ($match.Success) {
    $name = $match.Groups[1].Value
    $version = $match.Groups[2].Value
    if ($version -notin "-") {
      iex "dotnet add $proj package $name"
    }
  }
}