import unittest
import re
from KeyboardParser import findtraversestring
from KeyboardParser import parsetraverse


class TestTraverse(unittest.TestCase):
    def test_findtraversestring(self):
        self.assertEqual(findtraversestring("IT Crowd"),
                         "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#")
        self.assertEqual(findtraversestring("ocean's 11"),
                         "D,D,R,R,#,U,U,#,R,R,#,L,L,L,L,#,D,D,R,#,D,L,#,S,D,R,R,#,#")


    def test_parsetraverse(self):
        searchterm="12 O'Clock High"
        searchterm = re.sub('[^A-Za-z0-9 ]+', '', searchterm).lower()
        traverselist = findtraversestring(searchterm).split(',')
        self.assertEqual(parsetraverse(traverselist),  searchterm)


if __name__ == '__main__':
    unittest.main()
