using AutoProperties.Classes;

//  Testing Properties
Prop prop = new Prop();
prop.Name = "Property";
Console.WriteLine(prop.Name);

//  Testing Auto Properties
AutoProp autoProperties = new AutoProp();
autoProperties.Name = "Auto Property";
Console.WriteLine(autoProperties.Name);