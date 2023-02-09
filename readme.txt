# ======================================
# =============  README.TXT ============
# ======== TUTORIAL .NET BY ZAN ========
# ======================================

# commands 

1 -- Install package SqlServer : dotnet add packege Microsoft.EntityFrameworkCore.SqlServer --version 7.0.2

2 -- Install Migrations : dotnet tool install --global dotnet-ef
3 -- Install package Entity Design : dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.2

4 -- Add Table : dotnet ef migrations add [Table]Table (Ex.LangsTable)
5 -- Add Entity in Table : dotnet ef migrations add Add[Table][Entity] (Ex.AddUsersupdatedAt)
6 -- Refresh : dotnet ef migrations update


====== Extension VSCODE .NET ======
code --install-extension vscode-icons-team.vscode-icons
code --install-extension esbenp.prettier-vscode
code --install-extension ms-dotnettools.csharp
code --install-extension matijarmk.dotnet-core-commands
code --install-extension eamodio.gitlens
code --install-extension esbenp.prettier-vscode
code --install-extension bierner.color-info