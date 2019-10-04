import unittest
from keyboard_path import get_position, get_path, get_cursor_path


class TestKeyboardPath(unittest.TestCase):

    def test_position(self): # tests the get_position function
        self.assertEqual(get_position('3'), (4, 4), "Should be (4, 4)")
        self.assertEqual(get_position('0'), (5, 5), "Should be (5, 5)")
        self.assertEqual(get_position('A'), (0, 0), "Should be (0, 0)")
        self.assertEqual(get_position('T'), (3, 1), "Should be (3, 1)")

    def test_get_path(self): # tests the get_path function
        self.assertEqual(get_path((1, 2), (0, 0)), ['U', 'L', 'L', '#'], "Should be ['U', 'L', 'L']")
        self.assertEqual(get_path((3, 5), (2, 1)), ['U', 'L', 'L', 'L', 'L', '#'], "Should be ['U', 'L', 'L', 'L' 'L']")
        self.assertEqual(get_path((1, 1), (4, 5)), ['D', 'D', 'D', 'R', 'R', 'R', 'R', '#'], "Should be ['D', 'D', 'D', 'R', 'R', 'R', 'R']")


    def test_whole_path(self): # tests the get_cursor_path function (which uses the other two functions)
        self.assertEqual(','.join(get_cursor_path('IT Crowd')), 'D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#', "Should be D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#")   
        self.assertEqual(','.join(get_cursor_path('The Office')), 'D,D,D,R,#,U,U,#,U,R,R,R,#,S,D,D,L,L,#,U,U,R,R,R,#,#,D,L,L,L,#,U,#,R,R,#', "Should be D,D,D,R,#,U,U,#,U,R,R,R,#,S,D,D,L,L,#,U,U,R,R,R,#,#,D,L,L,L,#,U,#,R,R,#") 
        self.assertEqual(','.join(get_cursor_path('Iron Man 1')), 'D,R,R,#,D,R,R,R,#,L,L,L,#,L,#,S,L,#,U,U,#,D,D,R,#,S,D,D,R,#', "Should be D,R,R,#,D,R,R,R,#,L,L,L,#,L,#,S,L,#,U,U,#,D,D,R,#,S,D,D,R,#") 


if __name__ == '__main__':
    unittest.main(argv=['input.txt'], exit=False)

