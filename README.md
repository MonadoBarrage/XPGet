# XPGet
XPGet is used to calculate points each player gains after playing a board game based on ranking, time, and number of players.

Revisions:
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2022-01-08 

  * Default.aspx.cs
    - Removed Sigmoid function and any mention of it throughout the file
    - Modified BSOffset function
    - Heavily modified XPCalc function to provide more fairer calculations and distributions of points; all players earn a base amount of points with higher ranked players earning additional xp
    - Modified Button1_Click function; game modes it checks for are as follows: ranked, co-op, party, teams 
    - Modified ModeDropDownList_SelectedIndexChanged function to remove user input boxes for number of winners and losers
  * Default.aspx
    - Modified the drop-down list to include these game modes: Ranked, Co-op, Party, Teams
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Forked from Snaredrumhero's repository.

Main code in Defaut.aspx.cs 
JavaScript in Default.aspx
