<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="TestCloudServiceWWebRole" generation="1" functional="0" release="0" Id="1c508987-e6ce-4ed8-b7c5-cd27f67cdcd5" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="TestCloudServiceWWebRoleGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebRole6257:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/LB:WebRole6257:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebRole6257:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/MapWebRole6257:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole6257Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/MapWebRole6257Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebRole6257:Endpoint1">
          <toPorts>
            <inPortMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebRole6257:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole6257Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebRole6257" generation="1" functional="0" release="0" software="C:\Users\amaga\Documents\AzureTeamRampup\TestCloudServiceWWebRole\TestCloudServiceWWebRole\csx\Debug\roles\WebRole6257" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole6257&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole6257&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257Instances" />
            <sCSPolicyUpdateDomainMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebRole6257UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebRole6257FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebRole6257Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="54a2115f-8105-465b-83f1-bbdbd0b22c74" ref="Microsoft.RedDog.Contract\ServiceContract\TestCloudServiceWWebRoleContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="77a5abb8-19c7-4077-b2e8-4c57ea38c1cc" ref="Microsoft.RedDog.Contract\Interface\WebRole6257:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/TestCloudServiceWWebRole/TestCloudServiceWWebRoleGroup/WebRole6257:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>