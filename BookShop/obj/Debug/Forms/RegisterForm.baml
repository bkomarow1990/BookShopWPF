   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookShop.FormsBookShop.Forms  5   	       BookShop.Forms.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookShop.Forms     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  64     � WindowStartupLocation$  CenterScreen=�5   	   
������  � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � Title$ Register��5   	   $	��500��6   $	��400��6'    � 	Resources 5         ContextButtonStyle �� 
TargetType  MaterialDesignRaisedButton �� BasedOn �� Property �� Value��%�   &	        7  �� 5   
   " ��6+   8   .�5      ��  � ��
 ���� 6A   �� 5       � ��$ 0q�60   6=   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      6   �� 5      6   .+�5   
   �� $��3��6   
 �� CornerRadius$
 12��6"   ��5      �� 5      .��5      �  � Color$ #660099��6#    � Offset$	 0.1Q�63   6B   � 5      $ #C70039��6#   $ 1Q�63   6@   5      5       ]� 5!   
   $��0��6   .+�5*      �� -   5        $��CloseButton��5.   +   $��Right=�5*      $	��Top=�6-   $��Right=�6E   $��30��5+      $��30��6     + 'MaterialDesignFloatingActionLightButton#��[ 5-       � ToolTip$ CloseWindow��5.      $��10q�5/      ��5,      �� *CloseWindowCommand+.��51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�6*   $��24��6=   $��24��6H   52      �� 53      -   5        $��MinimizeButton��57   .   $��Right=�53      $	��Top=�6-   $��Right=�6E   $��30��54      $��30��6    #��[ 56      $ MinimizeWindow��57      $��0,10,0,0q�58      ��55      �� *MinimizeWindowCommand+.��5:        $ WindowMinimize=�6*   $��26��6@   $��24��6K   5;      5<      �� 5=   
   $��Center=�6   .+�5>      ��   BebasFontBook#��[ 6   
�������$��Center=�6X   $��32(�6u   
BookShop6�   �� 5B      $��Center=�6   ._�5C        
�������$
 Book=�6=   $	��100��6I   $	��100��6U   5D      5E      �� 5F   
    �� Orientation$ 
Horizontal=�6   $��0,70,0,0q�6.   $��1��6@   $	��Top=�6M   $��Center=�6e   .+�5G      G� -   5        $��passwordTxtBox��5G   b   $	��250��6   $��30��6&   4  .System.Windows.Automation.AutomationProperties   HelpText$ Enter Password��62   
�������$��	Helvetica)�6�   $��Light"�6�   5I        5J      $ LockQuestion=�6&   
�������$��Center=�6M   $��Center=�6j   $��25��6�   $��25��6�   5K      �� 5L   
   $ 
Horizontal=�6   $��0,20,0,0q�6.   $��1��6@   $	��Top=�6M   $��Center=�6e   .+�5M      �� -   5        $��usernameTxtBox��5M   �   $	��250��6   $��30��6"   $��0,0,0,1q�6.   
�������$��	Helvetica)�6[   $��Light"�6r   .��6�   Enter Username5P        5Q      $ Account=�6&   
�������$��Center=�6H   $��Center=�6e   $��25��6�   $��25��6�   5S      �� 5T   
   $ 
Horizontal=�6   $��1��6/   $��0,50,0,0q�6<   $��Center=�6N    � DataContext$  ��6k   .+�5U      �� -   5         ��Name$ registerBtn��5U      .��6D   
REGISTER6N   5V      5W      5X      