   M S B A M L   `   `   `  ����U  QEB.BedrijfswagenBeheer.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:EB.BedrijfswagenBeheer.App.Views EB.BedrijfswagenBeheer.App.Views  5      3    -EB.BedrijfswagenBeheer.App.Views.WagenAddView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:EB.BedrijfswagenBeheer.App.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   ��    
TitelStyle#��[  5      $��0��5      ��5      �� *Titel+5      � 5   
   $��1��5        5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      6%   .+�5"      �� $��	Filiaal: ��5#      $��Right=�5$      $��0��5%      $��0��6   5&      �� 5'      $��Bestuurder: ��5(      $��Right=�5)      $��1��5*      $��0��6   5+      �� 5,      $��Merk Wagen: ��5-      $��Right=�5.      $��2��5/      $��0��6   50      �� 51      $��Type Wagen: ��52      $��Right=�53      $��3��54      $��0��6   55      �� 57      $��0��58      $��1��6   ��59      �� *
Filialen+ �� SelectedItem 5:      �� *SelectedFiliaal+5<      �� 5=      $��1��5?      $��1��6   ��5>      �� *AddWagen.Bestuurder+5@      �� 5A      $��2��5C      $��1��6   ��5B      �� *AddWagen.Merk+5D      �� 5E      $��3��5G      $��1��6   ��5F      �� *AddWagen.Type+5H      5J      �� 5K   
   $��2��5L      .@�5N      �� -   5        $��Bewaar��5O      ��5P      �� *SaveCommand+5Q      �� 5R      $��Annuleer��5S      ��5T      �� *CancelCommand+5U      5V      5W      5X      