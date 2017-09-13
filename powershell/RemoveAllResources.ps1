$amit6257VStudioSubId = "c445e683-26aa-4df7-84da-fd2ba8a502e3"
$context = Get-AzureRmContext
if($context.Subscription.Id -eq $amit6257VStudioSubId) {
    $allres = Get-AzureRmResource
    foreach($res in $allres) {
        Write-Host "Deleting resource : " $res.Name
        Remove-AzureRmResource -ResourceId $res.ResourceId -Force
    }
} else {
    Write-Host "Incorrect subscription selected"
}
