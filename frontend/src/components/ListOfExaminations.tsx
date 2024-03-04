
import { Examination } from '../utils/Examination';
import { ExaminationBlock } from './ExaminationBlock';


export interface IListOfExaminations {
    examinations: Examination[]
}
  
export function ListOfExaminations({examinations} : IListOfExaminations) {
    return <>
    {examinations.length === 0 ?
      <p>Нет данных</p>:
      <ol>
        {examinations.map(examination =>
        <li key={examination.organizationOgrn}>
          <ExaminationBlock examination={examination}></ExaminationBlock>
        </li>)}
      </ol>
    }
    </> 
  }