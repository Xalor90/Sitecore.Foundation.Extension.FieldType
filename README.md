# Field Type Extension for Sitecore 9

This extension will allow you to add custom Field Types to Sitecore, such as the Static Options List.

## License
[MIT](/LICENSE.md)

## How to install:
- To begin, clone this repo into an existing Sitecore 9, Helix-based Solution under `/src/Foundation/Extension/FieldType`.
- Add the appropriate version of `Sitecore.Kernel` to this project from NuGet and build the project.
- Copy the contents of `/App_Config` into your primary web project alongside your existing `/App_Config` files.
- Add a reference of this project to your primary web app and rebuild the entire Solution.

## How to use:
- In Sitecore Admin CP, edit any data template and choose the `Static Options List` field type.
- For the `Source` field, enter a pipe-delimited list of all options you want to appear in the dropdown for this field (examples below).

### Source Examples:
Lists are pipe-delimited (|) and can be entered as key-value pairs by using the equals (=) sign:
- `Yes|No|Undecided`
- `1=Yes|2=No|0=Undecided`

## Attribution:
- [John West](https://community.sitecore.net/technical_blogs/b/sitecorejohn_blog/posts/static-options-list-for-the-sitecore-asp-net-cms)

The Static Options List was originally outlined in a blog post by John West (link above). While it was designed for ampersand-delimited (&) lists, for this project I decided to change it to pipe-delimited (|) lists.

**Note:** The decision to use pipes (|) is purely based on personal preference and can changed in the `StaticOptionsList` class file. Just search for `string[] kvPairs = Source.Split('|');`, then change the character in the `Split('|')` to whatever character you want (some characters may be reserved and not work).
