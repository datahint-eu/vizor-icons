# Vizor.Icons

[Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) icon packs.

- Available as **SVG** and **font** icons.
- Compatible with `>= .NET 6.0`
- MIT License (code)
  - Icon packs might have a different license. In that case, the entire package will use the same license.
- Makes use of code generators to transform each icon pack to a usable .NET package.

## Icon Packs

Currently the following icon packs are supported:

- Bootstrap Icons (MIT License): https://icons.getbootstrap.com/
- Tabler Icons (MIT License): https://tabler-icons.io/

## Quickstart

### Dependencies

Add a package reference to a specific icon pack (no additional dependencies):
- Vizor.Icons.Bootstrap
- Vizor.Icons.Tabler

### Usage in .razor files

Render an SVG icon (Bootstrap icon pack)
```
<BootstrapSvgIcon Icon="BootstrapSvgIcon.ExclamationTriangle" />
```

Render an SVG icon (Tabler icon pack) with custom styling.
```
<TablerSvgIcon Icon="TablerSvgIcon.ExclamationTriangle" CssClass="text-success" Width="32" Height="32" />
```

Use a font icon
```
<i class="BootstrapFontIcon.ExclamationTriangle" />
```

## Documentation

More documentation is available in the Readme.md file of each icon pack.

- [Bootstrap](https://github.com/datahint-eu/vizor-icons/tree/main/src/Vizor.Icons.Bootstrap)
- [Tabler](https://github.com/datahint-eu/vizor-icons/tree/main/src/Vizor.Icons.Tabler)

## Future work

Following icon packs might be added in the future, open a request to let me know you are interested:
- https://feathericons.com/
- https://heroicons.com/
- https://fontawesome.com/
- https://fonts.google.com/icons
- https://primer.style/octicons/
- https://simpleicons.org/
- https://materialdesignicons.com/
- https://flagicons.lipis.dev/
- https://github.com/bytedance/IconPark