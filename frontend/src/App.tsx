import React, { useEffect, useState } from 'react';
import './App.css';
import { request } from './utils/requester';
import { tryGetEnvAsInt } from './utils/envirenmentalist';
import { ListOfExaminations } from './components/ListOfExaminations';
import { Examination } from './utils/Examination';
import { SearchPage } from './utils/SearchPage';
import { PageSlider } from './components/PageSlider';

export default function App() {
  var [examinations, setExaminations] = useState<Examination[]>([]);
  var [currentPageNumber, setCurrentPageNumber] = useState<number>(1);

  useEffect(() => {
    var countElementsInPage = tryGetEnvAsInt(process.env.REACT_APP_COUNT_ELEMENT_IN_PAGE);
    var page = new SearchPage(countElementsInPage, currentPageNumber);
    request(page, setExaminations);
  }, [currentPageNumber ]);

  return <>
    <ListOfExaminations examinations={examinations}></ListOfExaminations>
    <PageSlider currentNumber={currentPageNumber} setNumber={setCurrentPageNumber}></PageSlider>
  </>
}
