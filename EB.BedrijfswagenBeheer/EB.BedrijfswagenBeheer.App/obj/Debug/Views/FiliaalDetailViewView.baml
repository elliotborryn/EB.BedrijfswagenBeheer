   M S B A M L   `   `   `  ����U  QEB.BedrijfswagenBeheer.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:EB.BedrijfswagenBeheer.App.Views EB.BedrijfswagenBeheer.App.Views  5      <    6EB.BedrijfswagenBeheer.App.Views.FiliaalDetailViewView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:EB.BedrijfswagenBeheer.App.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ��    
TitelStyle#��[  5      $��0��5      ��5      �� *Titel+5      � 5   
   $��1��5        5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      6"    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      6%   .+�5       �� $
��Id: ��5!      $��Right=�5"      $��0��5#      $��0��6   5$      �� 5%      $��Naam:��5&      $��Right=�5'      $��1��5(      $��0��6   5)      �� 5*      $��Wagens:��5+      $��Right=�5,      $��2��5-      $��0��6   5.      �� 5/      $��0��51      $��1��6   ��50      �� *
Filiaal.Id+52      �� 53      $��1��55      $��1��6   ��54      �� *Filiaal.Naam+56      �� 57      $��2��5:      $��1��6   ��58      �� *Filiaal.Wagens+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 59      �� *SelectedWagen+5;      5<      �� 5=   
   $��2��5>      $��48,0,0,-0.4q�6   .@�5@      �� $��	Toevoegen��5A      ��5B      �� *
AddCommand+5C      �� 5D      $��Wijzigen��5E      ��5F      �� *EditCommand+��5G      �� *SelectedWagen+5H      �� 5I      $��Verwijderen��5J      ��5K      �� *DeleteCommand+5L      5M      5N      5O      