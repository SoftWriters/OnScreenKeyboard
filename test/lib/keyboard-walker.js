import { expect } from 'chai';
import { resolve } from 'path';
import { walkString, walkFile } from '../../src/lib/keyboard-walker';

describe('keyboard-walker', () => {
  describe('#walkString', () => {
    it('uses # for found letters', () => {
      const path = walkString('A');
      expect(path).to.equal('#');
    });

    it('uses R and L for moving horizontally', () => {
      const path = walkString('ABCCBA');
      expect(path).to.equal('#,R,#,R,#,#,L,#,L,#');
    });

    it('uses U and D for moving vertically', () => {
      const path = walkString('AGMMGA');
      expect(path).to.equal('#,D,#,D,#,#,U,#,U,#');
    });

    it('uses S for spaces', () => {
      const path = walkString('AA BB AA');
      expect(path).to.equal('#,#,S,R,#,#,S,L,#,#');
    });

    it('creates a complex path with all of the above', () => {
      const path = walkString('It Crowd');
      expect(path).to.equal('D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#');
    });
  });

  describe('#walkFile', () => {
    it('walks a file and returns an array', (done) => {
      const filepath = resolve(__dirname, 'test.txt');
      walkFile(filepath, (err, strings) => {
        expect(strings).to.be.a('array');
        expect(strings[0]).to.equal('#');
        expect(strings[1]).to.equal('#,R,#,R,#,#,L,#,L,#');
        expect(strings[2]).to.equal('#,D,#,D,#,#,U,#,U,#');
        expect(strings[3]).to.equal('#,#,S,R,#,#,S,L,#,#');
        expect(strings[4]).to.equal('D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#');
        done();
      });
    });
  });
});
