import { expect } from 'chai';
import matrixGenerator from '../../src/lib/matrix-generator';

describe('matrixGenerator', () => {
  it('returns an array with correct number of columns', () => {
    const matrix = matrixGenerator(6);
    expect(matrix).to.be.a('array');
    expect(matrix).length(6);
  });

  it('returns the expected matrix', () => {
    const sixColumnMatrix = matrixGenerator(6);
    const sevenColumnMatrix = matrixGenerator(7);
    const expectedSixColumnMatrix = [
      ['a', 'b', 'c', 'd', 'e', 'f'],
      ['g', 'h', 'i', 'j', 'k', 'l'],
      ['m', 'n', 'o', 'p', 'q', 'r'],
      ['s', 't', 'u', 'v', 'w', 'x'],
      ['y', 'z', '1', '2', '3', '4'],
      ['5', '6', '7', '8', '9', '0']
    ];
    const expectedSevenColumnMatrix = [
      ['a', 'b', 'c', 'd', 'e', 'f', 'g'],
      ['h', 'i', 'j', 'k', 'l', 'm', 'n'],
      ['o', 'p', 'q', 'r', 's', 't', 'u'],
      ['v', 'w', 'x', 'y', 'z', '1', '2'],
      ['3', '4', '5', '6', '7', '8', '9'],
      ['0']
    ];

    expect(sixColumnMatrix).to.eql(expectedSixColumnMatrix);
    expect(sevenColumnMatrix).to.eql(expectedSevenColumnMatrix);
  });

  it('returns the expected matrix capitalized if needed', () => {
    const sixColumnMatrix = matrixGenerator(6, true);
    const expectedSixColumnMatrix = [
      ['A', 'B', 'C', 'D', 'E', 'F'],
      ['G', 'H', 'I', 'J', 'K', 'L'],
      ['M', 'N', 'O', 'P', 'Q', 'R'],
      ['S', 'T', 'U', 'V', 'W', 'X'],
      ['Y', 'Z', '1', '2', '3', '4'],
      ['5', '6', '7', '8', '9', '0']
    ];

    expect(sixColumnMatrix).to.eql(expectedSixColumnMatrix);
  });
});
