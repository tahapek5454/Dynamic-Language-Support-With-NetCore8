# Dynamic-Language-Support-With-NetCore8
+ The goal of the project is to insert a middleware into an API developed with NetCore 8, which operates between the Request and Response. The middleware, based on the language value corresponding to the **support_language** key written in the HTTP Request header, retrieves data from the database in a language-specific manner and configures it with AutoMapper to return as a Response.
+ All mentioned processes are designed to work dynamically.

## How to Use
+ Include the source code of the project in your own project.
+ To conform to the dynamically configured system using AutoMapper, you can use two different methods:
    + **MapFromLanguage Method**
        + Utilize the extended `MapFromLanguage` method to perform dynamic language mapping via a delegate I defined.
        + ```.ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));```
        + If defined as above, the system will automatically search for **Description_EN** or **DescriptionEN** in the header with the condition **en_EN** and assign it to the destination `dest.Description`. If the respective property is not defined, it will assign to **Description**. If that is also not available, it returns an empty string.
    + **DynamicLanguageResolver Method**
        + Another option is to benefit from the `DynamicLanguageResolver` class I created.
        + ```.ForMember(dest => dest.Name, opt => opt.MapFrom<DynamicLanguageResolver, string>(p=>"Name"))```
        + Here, it doesn't automatically take the selected property, but if you specify which property to search for in the parameter as shown, you provide a solution behind the scenes using reflection similar to the first method.

+ You can customize AutoMapper configurations by taking examples from the delegates I wrote.
    + This method works depending on the property and needs to be specifically written.
    + ```.ForMember(dest => dest.Name, opt => opt.MapFrom(MapFunc.ReturnNameLanguageDynamic))```
    + As you can see from the example, by creating a special delegate for the Name property, you can write your own delegates and use them in the way I wrote.
  
## Sample Distributions
+ Examples for fully dynamic operations are exemplified on the **Category** class, and examples for operations working specifically for each property are exemplified on the **Product** class in the project.
