import React, { useEffect, useState } from 'react';
import './App.css';
import { Examination, SearchPage, request } from './utils/requester';
import { tryGetEnvAsInt } from './utils/envirenmentalist';

export default function App() {
  var [examinations, setExaminations] = useState<Examination[]>([]);

  useEffect(() => {
    var countElementsInPage = tryGetEnvAsInt(process.env.REACT_APP_COUNT_ELEMENT_IN_PAGE);
    var page = new SearchPage(countElementsInPage, 1);
    request(page, setExaminations);
  }, []);

  return <>
    {examinations.length === 0 ?
      <p>Нет данных</p>:
      <ul>
        {examinations.map(examination =>
        <li key={examination.organizationOgrn}>
          <ExaminationBlock examination={examination}></ExaminationBlock>
        </li>)}
      </ul>
      }
  </>
}

interface IExaminationBlock {
  examination: Examination
}

function ExaminationBlock({examination}: IExaminationBlock) {
  return <div style={{border:'2px solid blue'}}>
    <p>Полное название организации: {examination.organizationFullName}</p>
    <p>ОГРН организации: {examination.organizationOgrn}</p>
    <p>Цель проверки: {examination.examObjective}</p>
    <p>Результат проверки: {examination.examinationResult}</p>
    <p>Статус проверки: {examination.examinationStatus}</p>
  </div>
}

