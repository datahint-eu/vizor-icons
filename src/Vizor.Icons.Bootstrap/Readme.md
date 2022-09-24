# Vizor - Bootstrap icon pack

## Includes

**SVG icons** do not require any additional imports.

**Font icons** require the following css to be included:
```
<link rel="stylesheet" href="_content/Vizor.Icons.Bootstrap/css/bootstrap-icons.css">
```

## Namespace

Add the following namespace to **_Imports.razor**
```
@using Vizor.Icons.Bootstrap
```

## Usage

### SVG Icons

```
<BootstrapSvgIcon Icon="BootstrapSvgIcon.ExclamationTriangle" />
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
<i class="BootstrapFontIcon.ExclamationTriangle" />
```

## Contributin

### Compiling

1. Make sure you have a recent version of nodejs installed (>= 18)
2. Install gulp (only once)
```
npm install --global gulp-cli
npm install --save-dev gulp gulp-clean
```
3. Install bootstrap-icons from npm
```
npm install bootstrap-icons
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
    "bootstrap-icons": "1.9.1"
}
```
2. Run npm update
```
npm update bootstrap-icons
```
3. Run gulp
4. Update Vizor.Icons.Bootstrap.csproj to the correct version
```
<Version>1.9.1.0</Version>
```
5. Rebuild the package