Mariuzzo.DO.DataAnnotations
===========================

Provides common and useful validation attributes for Dominican Republic (DO).

Installation
------------

To install [Mariuzzo.DO.DataAnnotations](http://nuget.org/packages/Mariuzzo.DO.DataAnnotations/), run the following command in the NuGet's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    Install-Package Mariuzzo.DO.DataAnnotations

Documentation
=============

CedulaAttribute
---------------

Validate a Cédula.

### Example ###

    [Cedula]
    public String Cedula { get; set; }

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

    [BbPin]
    public String BbPin { get; set; }

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

    [MSISDN]
    public String BbPin { get; set; }

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

As most projects nowadays, just fork this repository, put your hands in the code, then send me a pull request.

Do you prefer to talk? [Send me a message](https://github.com/rmariuzzo).