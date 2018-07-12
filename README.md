# Field Type Extension for Sitecore 9

This extension will allow you to add custom Field Types to Sitecore, such as the Static Options List.

## License
[MIT](/LICENSE.md)

## How to install (Manual):
- To begin, clone this repo into an existing Sitecore 9, Helix-based Solution under `/src/Foundation/Extension/FieldType`.
- Add the appropriate version of `Sitecore.Kernel` to this project from NuGet and build the project.
- Add a reference of this project to your primary web app and rebuild the entire Solution.
- In the Sitecore Admin CP, open the Content Editor for the `core` database.
- Under `/sitecore/system/Field types/List Types/`, create a new item from template `/sitecore/templates/System/Templates/Template field type`.
- Name the item `Static Options List`.
- Set `Assembly` to `Sitecore.Foundation.Extension.FieldType`.
- Set `Class` to `Sitecore.Foundation.Extension.FieldType.Shell.Applications.ContentEditor.StaticOptionsList`.

## How to use:
- In the Sitecore Admin CP, edit any data template and choose the `Static Options List` field type.
- For the `Source` field, enter a pipe-delimited list of all options you want to appear in the dropdown for this field (examples below).

### Source Examples:
Lists are pipe-delimited (|) and can be entered as key-value pairs by using the colon (:) sign:
- `Yes|No|Undecided`
- `1:Yes|2:No|0:Undecided`

## Attribution:
- [John West](https://community.sitecore.net/technical_blogs/b/sitecorejohn_blog/posts/static-options-list-for-the-sitecore-asp-net-cms)

The Static Options List was originally outlined in a blog post by John West (link above). While it was designed for ampersand-delimited (&) lists and equal-separated (=) key-value pairs, for this project I decided to change it to pipe-delimited (|) lists and colon-separated (:) key-value pairs.

**Note:** The decision to use pipes (|) and colons (:) is purely based on personal preference and can be changed in the `StaticOptionsList` class file. Just search for `string[] kvPairs = Source.Split('|');`, then change the character in the `Split` to whatever character you want (some characters may be reserved and will not work). Likewise, to change the key-value separator, look for `int i = kvPair.IndexOf(":");` and change the value in the `IndexOf` portion.
