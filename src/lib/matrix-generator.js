import config from '../config';

export default function matrixGenerator(columns, upperCase) {
  const maxKeys = config.keyboard.keys.length;
  const numberOfRows = Math.ceil(maxKeys / columns);
  const matrix = [];

  for (let i = 0; i < numberOfRows; i += 1) {
    const multiplier = i * columns;
    const currentRow = config.keyboard.keys.slice(multiplier, multiplier + columns);
    matrix.push(
      currentRow.map(character => upperCase ? character.toUpperCase() : character)
    );
  }
  return matrix;
}
