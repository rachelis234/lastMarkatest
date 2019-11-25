import { Test } from './Test';
import { Question } from './Question';
import { Answer } from './Answer';

export class SolveTest{
    test:Test;
    questions:Question[];
    answers:Answer[];
    selectedAnswer:Array<Answer>;
}