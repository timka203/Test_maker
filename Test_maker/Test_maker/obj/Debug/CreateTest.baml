   M S B A M L   `   `   `  ����E  ATest_maker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Test_maker
Test_maker  5   	       Test_maker.CreateTest   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Test_maker     5   	     � Title$  
CreateTest��5   	   $	��650��6   $	��700��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   .+�5      �� .��6   Description6!   �� 5      -   5         ��Name$ txtDes��5      6)   5      �� 5      $��1��6   $ Vertical=�6&    �� CanVerticallyScroll . .+�5      �� .��6   	Questions6#   �� 5      .��5      �� -   5         ��Name$ lbtquest��5      $��60��6,   ��. 5      5      �� 5      -   5         ��Name$ spques��5      .+�5       �� .��6   
Question6&   �� 5!      -   5        $ txtquest��5!      62   �� 5"      .��6   	Answer16%   �� 5#      -   5        $ txtans1��5#      61   �� 5$      .��6   
IsRight?6"   	� 5%      -   5         	�Name$ isright1��5%       d� 	IsChecked$ FalseY�60   6D   �� 5&      .��6   	answer26%   �� 5'      -   5        $ txtans2��5'      61   �� 5(      .��6   
IsRight?6"   	� 5)      -   5        $ isright2��5)      $ FalseY�61   6E   �� 5*      .��6   	answer36!   �� 5+      -	   5        $ txtans3��5+      61   �� 5,      .��6   
IsRight?6"   	� 5-      -
   5        $ isright3��5-      $ FalseY�61   6E   �� 5.      .��6   	answer46!   �� 5/      -   5        $ txtans4��5/      61   �� 50      .��6   
IsRight?6"   	� 51      -   5        $ isright4��51      $ FalseY�61   6E   �� 52      -   5        $
 spcb��52   I   $ 
Horizontal=�6   {�.  55      �� 56      -   5        $
 sptb��56   /   {�.  .+�57      �� $��Price��6   �� 58      -   5        $ txprc��58      59      5:      �� 5<      -   5        	 ��Name$	 btn_add_quest��5<      $��Add question��6H   6a   5=      �� 5?   
   -   5        $	 
btnCrtTest��5?      $��2��6   $��  Create test��6L   5A      �� 5B   
   -   5        $
	 Back��5B      $��3��6   $
��Back��6A   5D      5E      