   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookShopBookShop  5   	       BookShop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BookShop     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6.   -   5          � AllowsTransparency  .  � WindowStyle$
 None=�5	   	   
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��500��6   $	��400��6)    � 	Resources 5         ContextButtonStyle �� 
TargetType  MaterialDesignRaisedButton �� BasedOn �� Property �� Value��%�   &	        7  �� 5   
   " ��6+   8   .�5      ��  � ��
 ���� 6A   �� 5       � ��$ 0q�60   6=   5      5      .��5      � .+�5   
   � 	 � RowDefinitions	 5      �� 5      6"   �� 5      6"   .+�5!      �� $��3��6   
 �� CornerRadius$
 12��6&   ��5"      �� 5#      .��5$      �  � Color$ #660099��6'    � Offset$	 0.1Q�67   6F   � 5%      $ #C70039��6'   $ 1Q�67   6D   5&      5(      ]� 5)      $��0��6   .+�52      �� -   5        $��CloseButton��56   +   $��Right=�52      $	��Top=�61   $��Right=�6I   $��30��53      $��30��6     + 'MaterialDesignFloatingActionLightButton#��[ 55       � ToolTip$ CloseWindow��56      $��10q�57      ��54      �� *CloseWindowCommand+.��59      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�6.   $��24��6A   $��24��6L   5:      �� 5;      -   5        $��MinimizeButton��5?   .   $��Right=�5;      $	��Top=�61   $��Right=�6I   $��30��5<      $��30��6    #��[ 5>      $ MinimizeWindow��5?      $��0,10,0,0q�5@      ��5=      �� *MinimizeWindowCommand+.��5B        $ WindowMinimize=�6.   $��26��6D   $��24��6O   5C      5D      �� 5E      $��Center=�6   .+�5F      ��   BebasFontBook#��[ 6   
�������$��Center=�6\   $��32(�6y   
BookShop6�   �� 5J      $��Center=�6   ._�5K        
�������$
 Book=�6A   $	��100��6M   $	��100��6Y   5L      5M      �� 5N       �� Orientation$ 
Horizontal=�6   $��0,70,0,0q�62   $��1��6D   $	��Top=�6Q   $��Center=�6i   .+�5O      G� -   5        $��passwordTxtBox��5O   e   $	��250��6   $��30��6*   4  .System.Windows.Automation.AutomationProperties   HelpText$ Enter Password��66   
�������$��	Helvetica)�6�   $��Light"�6�   5Q        5R      $ LockQuestion=�6*   
�������$��Center=�6Q   $��Center=�6n   $��25��6�   $��25��6�   5S      �� 5T      $ 
Horizontal=�6   $��0,20,0,0q�62   $��1��6D   $	��Top=�6Q   $��Center=�6i   .+�5U      �� -   5        $��loginTxtBox��5U   _   $	��250��6   $��30��6&   $��0,0,0,1q�62   
�������$��	Helvetica)�6r   $��Light"�6�   .��6�   Enter Username5X        5Y      $ Account=�6*   
�������$��Center=�6L   $��Center=�6i   $��25��6�   $��25��6�   5[      �� 5\      $ 
Horizontal=�6   $��1��63   $��0,50,0,0q�6@   $��Center=�6R   .+�5]      �� -   5        $��loginBtn��5]   +   $��0,0,26,0q�6   .��6R   LOGIN6Y   �� 5^      ��6   �� *RegisterWindowCommand+.��6D   
REGISTER6N   5_      5`      5a      5b      