Mariuzzo.DO.DataAnnotations
===========================

Provides common and useful validation attributes for Dominican Republic (DO).

Installation
------------

To install [Mariuzzo.DO.DataAnnotations](http://nuget.org/packages/Mariuzzo.DO.DataAnnotations/), run the following command in the NuGet's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    Install-Package Mariuzzo.DO.DataAnnotations

Documentation
-------------

### CedulaAttribute ###

Validate a Cédula.

#### Example ####

    [Cedula]
    public String Cedula { get; set; }


### BbPinAttribute ###

Validate a BlackBerry PIN. 

#### Example ####

    [BbPinAttribute]
    public String BbPin { get; set; }

Do you want to contribute?
--------------------------

As most projects nowadays, just fork this repository, put your hands in the code, then send me a pull request.

Do you prefer to talk? [Send me a message](https://github.com/rmariuzzo).