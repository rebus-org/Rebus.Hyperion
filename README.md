# Rebus.Hyperion

[![install from nuget](https://img.shields.io/nuget/v/Rebus.Hyperion.svg?style=flat-square)](https://www.nuget.org/packages/Rebus.Hyperion)

Provides a [Hyperion](https://github.com/akkadotnet/Hyperion) serializer for [Rebus](https://github.com/rebus-org/Rebus).

![](https://raw.githubusercontent.com/rebus-org/Rebus/master/artwork/little_rebusbus2_copy-200x200.png)

---

Just go

```csharp
Configure.With(...)
	.(...)
	.Serialization(s => s.UseHyperion())
	.Start();
```

and have fun serializing.