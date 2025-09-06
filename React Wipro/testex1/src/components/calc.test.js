import Calc from './calc';

describe('Calc Module', () => {
    test('adds two numbers correctly', () => {
        expect(Calc.sum(2, 3)).toBe(5);
        expect(Calc.sum(-1, 1)).toBe(0);
    });

    test('subtracts two numbers correctly', () => {
        expect(Calc.sub(5, 3)).toBe(2);
        expect(Calc.sub(1, 1)).toBe(0);
    });

    test('multiplies two numbers correctly', () => {
        expect(Calc.mult(3, 4)).toBe(12);
        expect(Calc.mult(0, 5)).toBe(0);
    });
});