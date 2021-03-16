[TOC]

# 增值税电子发票开票系统

> 该项目为演示项目，其中用到了服务注册和身份认证，如果您需要使用这个项目，请在拉下代码后手动注释或修改服务注册和身份认证部分代码

```c#
...
app.UseSwaggerUI(option =>
{
	option.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice");
});

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
});

// RegisterConsul(hostApplicationLifetime);
...
```

