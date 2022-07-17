# NSwag sample

An autogenerate client using NSwag

`SampleApi` - sample service with open API 
* Get and save [json](https://localhost:7198/swagger/v1/swagger.json)

`NSwagApi` - service with autogenerated client
* install nugets `NSwag.ApiDescription.Client` and `Newtonsoft.Json`
``` csharp
<ItemGroup>
    <OpenApiReference Include="ExternalApi\Sample.json">
        <ClassName>SampleApiClient</ClassName>
        <CodeGenerator>NSwagCSharp</CodeGenerator>
        <Namespace>Sample</Namespace>
            <Options>/GenerateClientInterfaces:true /UseBaseUrl:false /GenerateOptionalPropertiesAsNullable:true /GenerateExceptionClasses:true</Options>
    </OpenApiReference>
</ItemGroup>
```

You can also extend the autogenerated model
``` csharp
namespace Sample;

public partial class WeatherForecast
{
    public string AdditionalField { get; set; }
}
```
