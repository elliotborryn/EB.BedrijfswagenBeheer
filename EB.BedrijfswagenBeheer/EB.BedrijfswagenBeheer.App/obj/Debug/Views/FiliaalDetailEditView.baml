   M S B A M L   `   `   `  ����U  QEB.BedrijfswagenBeheer.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:EB.BedrijfswagenBeheer.App.Views EB.BedrijfswagenBeheer.App.Views  5      <    6EB.BedrijfswagenBeheer.App.Views.FiliaalDetailEditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:EB.BedrijfswagenBeheer.App.Views     5      .��5	      �   � RowDefinitions  5
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
��Id: ��5!      $��Right=�5"      $��0��5#      $��0��6   5$      �� 5%      $��Naam: ��5&      $��Right=�5'      $��1��5(      $��0��6   5)      �� 5/      $��0��51      $��1��6   ��50      �� *EditFiliaal.Id+52      �� 53      $��1��55      $��1��6   ��54      �� *EditFiliaal.Naam+56      5;      �� 5<   
   $��2��5=      .@�5?      �� $��Bewaar��5@      ��5A      �� *SaveCommand+5B      �� 5C      $��Annuleer��5D      ��5E      �� *CancelCommand+5F      5G      5H      5I      