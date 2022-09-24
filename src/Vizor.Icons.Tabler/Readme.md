# Vizor - Tabler icon pack

## Includes

Add a package reference to **Vizor.Icons.Tabler**.
```
TODO
```

**SVG icons** do not require any additional imports.

**Font icons** require the following css to be included:
```
<link rel="stylesheet" href="_content/Vizor.Icons.Tabler/css/tabler-icons.min.css">
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

### Font Icons

```
<i class="TablerFontIcon.AlertTriangle" />
```

## Contributing

### Compiling

1. Make sure you have a recent version of nodejs installed (>= 18)
2. Install gulp (only once)
```
npm install --global gulp-cli
npm install --save-dev gulp gulp-clean
```
3. Install @tabler/icons from npm
```
npm install @tabler/icons
```
4. Run the gulp build script to retrieve all dependencies.
```
gulp
```

See https://gulpjs.com/docs/en/getting-started/quick-start/ for more information.

### Updates

1. Update the dependency version in package.json to the latest version
```
"dependencies": {
    "@tabler/icons": "1.100.0"
}
```
2. Run npm update
```
npm update @tabler/icons
```
3. Run gulp
4. Update Vizor.Icons.Tabler.csproj to the correct version
```
<Version>1.100.0.0</Version>
```
5. Rebuild the package