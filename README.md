Deprecated: https://developer.squareup.com/docs/web-payments/migrate

# SquareApi-AspNetCoreMvc-Demo
### ** demo for class I was TA for in college
Square api:

Download this nuget package:
`
Install-Package Square -Version 10.0.0
`

you must add stylesheet - find it here: sq-payment-form.css

must add javascript exacltly with asterisks *

sandbox credit card:

4111 1111 1111 1111
cvv 111
exp 12/21
postal 11111



https://github.com/square/connect-api-examples/tree/d88468dfb29d0400d0eed2c2b3d8c60acd383938/connect-examples/v2/csharp_payment


Links:

https://developer.squareup.com/docs/payment-form/payment-form-walkthrough

</br>

https://github.com/square/connect-api-examples/tree/d88468dfb29d0400d0eed2c2b3d8c60acd383938/connect-examples/v2/csharp_payment


Adding stylesheet to project:

﻿Changes in Layout:

line 9 through 17 - add style sheet

you must add this style sheet under wwwroot - download it at bootswatch.com


line 23 through 37 - make changes to css classes and navbar/link formatting 

Changes in Login Partial:

Where - <a  class="nav-link text-dark

Put -   <a  class="nav-link"

<button class="btn btn-link text-light"

all source code is here to copy:

bootswatch.com

bootwatch.com/lux





