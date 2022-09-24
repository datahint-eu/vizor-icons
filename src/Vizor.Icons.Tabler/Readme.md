# Vizor - Tabler icon pack

## Includes

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