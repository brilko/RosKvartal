import { Examination } from "../utils/Examination"


export interface IExaminationBlock {
    examination: Examination
}
  
export function ExaminationBlock({examination}: IExaminationBlock) {
    return <div style={{border:'2px solid blue'}}>
        <p>Полное название организации: {examination.organizationFullName}</p>
        <p>ОГРН организации: {examination.organizationOgrn}</p>
        <p>Цель проверки: {examination.examObjective}</p>
        <p>Результат проверки: {examination.examinationResult}</p>
        <p>Статус проверки: {examination.examinationStatus}</p>
    </div>
}