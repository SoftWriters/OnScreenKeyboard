import fs from 'fs';
import matrixGenerator from './matrix-generator';
import config from '../config';

export function walkString(string) {
  const keyboardMatrix = matrixGenerator(config.keyboard.size);
  const explodedWord = string.split('');
  let currentRow = 0;
  let currentColumn = 0;
  let lettersFound = 0;
  let path = '';

  while (lettersFound < explodedWord.length) {
    const currentLetter = explodedWord[lettersFound].toLowerCase();
    // Set for spaces
    if (currentLetter === ' ') {
      path += 'S';
      lettersFound += 1;
    // Check for whether it exists in this row.
    } else if (keyboardMatrix[currentRow].includes(currentLetter)) {
      const foundIndex = keyboardMatrix[currentRow].indexOf(currentLetter);
      if (foundIndex > currentColumn) {
        // Move right
        while (foundIndex > currentColumn) {
          path += 'R';
          currentColumn += 1;
        }
      }
      // Move left
      if (foundIndex < currentColumn) {
        while (foundIndex < currentColumn) {
          path += 'L';
          currentColumn -= 1;
        }
      }
      // Found it.
      path += '#';
      currentColumn = foundIndex;
      lettersFound += 1;
    } else {
      // Doesn't exist in current row, lets find it.
      let jumpTo = currentRow;
      keyboardMatrix.forEach((row, i) => {
        if (row.includes(currentLetter)) {
          jumpTo = i;
        }
      });

      // Jump up rows
      if (jumpTo > currentRow) {
        path += Array(jumpTo - currentRow).fill('D').join('');
      // Jump down rows.
      } else if (jumpTo < currentRow) {
        path += Array(currentRow - jumpTo).fill('U').join('');
      }
      currentRow = jumpTo;
    }
  }
  // Completed path
  return path.split('').join(',');
}

export function walkFile(filepath, callback) {
  return fs.readFile(filepath, (err, data) => {
    if (err) return console.error('Couldn\'t read file');
    return callback(null, data.toString().split('\n').map(string => walkString(string)));
  });
}
