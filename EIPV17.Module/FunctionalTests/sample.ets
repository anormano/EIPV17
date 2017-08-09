;#DropDB EIPV17EasyTest

#Application EIPV17.Win
#Application EIPV17.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef EIPV17.Win

*Action About...
 
*Action OK

#EndIf

#IfDef EIPV17.Web
*Action Navigation(My Details)
#EndIf
