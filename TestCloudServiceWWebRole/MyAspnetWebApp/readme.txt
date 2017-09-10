tutorial link : https://app.pluralsight.com/player?course=implementing-restful-aspdotnet-web-api&author=shawn-wildermuth&name=restful-aspdotnet-m2&clip=1&mode=live

1. created and asp.net project, able to call its controller from postman using: http://localhost:2820/api/values
2. after hosting on azure, it can be reached here : http://myaspnetwebapiapp6257.azurewebsites.net/api/values
response is 
[
    "value1",
    "value2"
]
3. get with a parameter: http://localhost:2820/api/values/12, response: "value passed = 12"
4. 