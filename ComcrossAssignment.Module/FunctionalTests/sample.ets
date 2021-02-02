;#DropDB ComcrossAssignmentEasyTest

#Application ComcrossAssignmentWin
#Application ComcrossAssignmentWeb
#IfDef ComcrossAssignmentWin

*Action About...
 
*Action OK

#EndIf

#IfDef ComcrossAssignmentWeb
!Action Navigation(My Details)
#EndIf
