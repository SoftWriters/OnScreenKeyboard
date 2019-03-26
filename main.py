import Tkinter
import tkFileDialog


def save_file():
    """Get the user to Create or overwrite a file.
    :return: Returned the opened file
    """
    root = Tkinter.Tk()
    root.withdraw()
    return tkFileDialog.asksaveasfile("w", title="Create Save file", filetypes=[('csv', '.csv'), ('txt', '.txt'),
                                                                                ('All', '*.*')])


def get_file():
    """Get the user to select the file.
    :return: Returned the opened file
    """
    root = Tkinter.Tk()
    root.withdraw()
    return tkFileDialog.askopenfile("r", title="Select input file", filetypes=[('txt', '.txt'), ('csv', '.csv'),
                                                                               ('All', '*.*')])


class Keyboard:
    """
    Class to represent a keyboard
    keyboard: Dictionary data from report to graph
    step: the column name to put on the Y-axis
    """
    keyboard = []
    step = None

    def __init__(self, keyboard=[], step=6):
        """
        Initializes keyboard class
        :param keyboard: Optional list param to initializes the keyboard letters available in the correct order
        :param step: Optional list param to set step/breakpoints/max length of line in a keyboard. Default 6
        """
        self.keyboard = keyboard or ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q'
                                        , 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7'
                                        , '8', '9', '0']
        self.step = step

    def get_index(self, char):
        """
        Returns where the character exists in the keyboard list.
        :param char: The character being looked up.
        :return: index of the character
        """
        return self.keyboard.index(char.capitalize())

    def get_pos(self, char):
        """
        Gets a tuple position of the character
        :param char: Input character to look up
        :return: Returns a tuple position
        """
        index = self.get_index(char)
        return divmod(index, self.step)


class Pointer:
    """
    Class to represent a mouse pointer
    """
    # Sample Colors available for columns
    position = None

    def __init__(self, position=(0, 0)):
        """
        Initializes the CSV Draw class
        :position keyboard: Optional list param to initializes the keyboard letters available in the correct order
        """
        self.position = position

    def move(self, pos):
        """
        Function to calculate how to move the pointer.
        :param pos: New position of type tuple
        :return: List of characters/moves needed to execute the pointer move.
        """
        travel = tuple(map(lambda x, y: x - y, pos, self.position))
        # Getting path
        path = []
        path += ['D']*travel[0]
        path += ['U'] * (- travel[0])
        path += ['R'] * travel[1]
        path += ['L'] * (- travel[1])
        path.append('#')
        self.position = pos
        return path




def main():
    """
    Main function
    """

    # File operations
    input_file = get_file()
    assert input_file, "No input file read!"
    output_file = save_file()
    assert output_file, "No output file set!"

    # Loop to get path
    keyboard = Keyboard()
    for line in input_file:
        line = line.rstrip('\n')
        mouse = Pointer()
        path = []
        for letter in line:
            if letter == ' ':
                path.append("S")
                continue
            try:
                pos = keyboard.get_pos(letter)
                path += mouse.move(pos)
            except ValueError:
                print "failed to map '" + letter + "' in '" + line + "'. skipping it."
                continue
        output_file.writelines(",".join(path) + "\n")
    input_file.close()
    output_file.close()


if __name__ == '__main__':
    main()
