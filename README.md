# XPGet
XPGet is used to calculate points each player gains after playing a board game based on ranking, time, and number of players.  
Link to Current Website: https://xpgetsystem.azurewebsites.net/ 
Revisions:
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2022-01-27
 * Web App
   - Website has now been built and published online to be used. Microsoft Azure used to publish. 
   - Link: https://xpgetsystem.azurewebsites.net/
 * Default.aspx.cs
   - Further modified the code 
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2022-01-16
 * Default.aspx.cs
   - Modified XPCalc function so that bigger groups earn more points than smaller groups in ranked play. Also changed calculations in party/team/co-op games so that they earn what second place earns in ranked plays.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2022-01-16
 * Default.aspx.cs
   - Removed BSOffset function

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2022-01-08 

  * Default.aspx.cs
    - Removed Sigmoid function and any mention of it throughout the file
    - Modified BSOffset function
    - Heavily modified XPCalc function to provide more fairer calculations and distributions of points; all players earn a base amount of points with higher ranked players earning additional xp
    - Modified Button1_Click function; game modes it checks for are as follows: Ranked, Co-op, Party, Teams 
    - Modified ModeDropDownList_SelectedIndexChanged function to remove user input boxes for number of winners and losers
  * Default.aspx
    - Modified DropDownList to include these game modes: Ranked, Co-op, Party, Teams
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Forked from Snaredrumhero's repository.

Main code in Defaut.aspx.cs   
JavaScript in Default.aspx
