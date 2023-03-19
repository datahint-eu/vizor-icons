# Vizor - Tabler icon pack

## Includes

Add a package reference to **Vizor.Icons.Tabler**.
```
<PackageReference Include="Vizor.Icons.Tabler" Version="2.11.0" />
```

## Namespace

Add the following namespace to **_Imports.razor**
```
@using Vizor.Icons.Tabler
```

## Usage

### SVG Icons

```
<TablerSvgIcon Icon="TablerSvgIcon.ExclamationTriangle" />
```

| Property | Type     | Description                                                                     |
| :------- | :------- | :------------------------------------------------------------------------------ |
| Icon     | IconData | **Required**. The icon to show.                                                 |
| Width    | string?  | Optional icon width. Overwrites the default if set.                             |
| Height   | string?  | Optional icon height. Overwrites the default if set.                            |
| CssClass | string?  | **Additional** CSS classes. The value is appended to the svg *class* attribute. |
| Fill     | string?  | Optional fill. Overwrites the default if set.                                   |
| ViewBox  | string?  | Optional viewBox. Overwrites the default if set.                                |

## Contributing

### Compiling

1. Make sure you have a recent version of nodejs installed (>= 18)
```
2. Install @tabler/icons from npm
```
npm install @tabler/icons
```

### Updates

1. Update the dependency version in package.json to the latest version
```
"dependencies": {
    "@tabler/icons": "2.11.0"
}
```
2. Run npm update
```
npm update @tabler/icons
```
3. Update Vizor.Icons.Tabler.csproj to the correct version
```
<Version>2.11.0</Version>
```
4. Rebuild the package