   M S B A M L   `   `   `  ����N  JEXIF文件修改器, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication4WpfApplication4  5   	        WpfApplication4.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication4     5   	     � Title$  EXIF文件修改器��5   	   $	��350��6   $	��525��6(    � WindowState$ 	Maximized=�64   .��5	      � .+�5
   
   � -   5        $��Gridd��5
      $��Right=�6   $��0,10,0,0q�69   $	��177��6K   .+�5      �� -   5         ��Name$ 
MeasureImg��5      $��添加测量��6)   $��
57,68,45,0q�68   $	��Top=�6L   6d   �� 5      -   5        $ 	RemarkImg��5      $��备注��6;   $��57,129,45,0q�6H   $	��Top=�6]   �� 5      -   5        $ GetImg��5      $��导入图片��6:   $��57,180,45,90q�6I   $	��Top=�6_   5      A� 5   
   $��50��6   $	��100��6   $��382,239,35,31q�6*   ��5      �� 5      -   5        ellipseBrush�� �� Color$ 	SteelBlue��5   8    � Triggers 5      :� 5       :� RoutedEvent$ Ellipse.Loaded��6   [�5      �� 5      .��5      ��  g� Duration$ 00:00:06D�6)    g� RepeatBehavior$ Forever��6=   .��5   "   W�  �� TargetProperty$ (Ellipse.Width)�5   %   $ 0:0:3D�5   %   	 g� AutoReverse	 . 
 g� FillBehavior$

 Stop=�5   %   $ Forever��5   %    g� AccelerationRatio$	 0.9Q�5    %    g� DecelerationRatio$	 0.1Q�6=    W� From$	 100X�6U   	 W� To$	 300X�6`   5"      5#      5%      5'      �� 5(   
   -   5         ��Name$ Imagee��5(   �   $��
5,0,182,10q�6�   .+�5)      �� -   5         ��Name$ 	textBlock��5+   J   
���2͚� �� TextWrapping$
 Wrap=�6]   $	��Top=�6q    J� Opacity$
 0.93Q�6�   $	��182��6�    �� Left$ 0��6�   ��6�   �� *ActualWidth+ �� ElementName$ Imagee��5-      5.      5/      