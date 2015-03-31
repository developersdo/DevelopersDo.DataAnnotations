DevelopersDo.DataAnnotations
===========================

> Provides common and useful validation attributes for Dominican Republic (DO).

Installation
------------

To install [DevelopersDo.DataAnnotations](http://nuget.org/packages/DevelopersDo.DataAnnotations/), run the following command in the NuGet's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```powershell
Install-Package DevelopersDo.DataAnnotations
```

Documentation
=============

CedulaAttribute
---------------

Validate a Cédula.

### Example ###

```cs
[Cedula]
public String Cedula { get; set; }
```

### Test ###

| Input           | Output  |
|-----------------|---------|
| "001-0068331-7" | `true`  |
| "00100683317"   | `true`  |
| `null`          | `true`  |
| ""              | `true`  |
| "foo"           | `false` |
| "001-2222222-2" | `false` |
| "00122222222"   | `false` |
| " "             | `false` |
| "\t"            | `false` |
| "\n"            | `false` |
| "\n \t"         | `false` |

BbPinAttribute
--------------

Validate a BlackBerry PIN. 

### Example ###

```cs
[BbPin]
public String BbPin { get; set; }
```

### Test ###

| Input           | Output  |
|-----------------|---------|
| "223CEC0A"      | `true`  |
| `null`          | `true`  |
| ""              | `true`  |
| "223CEC0"       | `false` |
| "223CEC0AA"     | `false` |
| " "             | `false` |
| "\t"            | `false` |
| "\n"            | `false` |
| "\n \t"         | `false` |

MSISDNAttribute
---------------

Validate a Dominican MSISDN.

### Example ###

```cs
[MSISDN]
public String PhoneNumber { get; set; }
```

### Test ###

| Input           | Output  |
|-----------------|---------|
| "8091234567"    | `true`  |
| "809-123-4567"  | `true`  |
| `null`          | `true`  |
| ""              | `true`  |
| "foo"           | `false` |
| "0211234567"    | `false` |
| "021-123-4567"  | `false` |
| " "             | `false` |
| "\t"            | `false` |
| "\n"            | `false` |
| "\n \t"         | `false` |


Do you want to contribute?
--------------------------

As most projects nowadays, just fork this repository, get your hands on the code, then send me a pull request.

Do you prefer to talk? [Send us a message](https://github.com/developersdo).
