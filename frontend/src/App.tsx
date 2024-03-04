import React from 'react';
import './App.css';
import { SearchPage, request } from './utils/requester';
import { tryGetEnvAsInt } from './utils/envirenmentalist';

function App() {
  var countElementsInPage = tryGetEnvAsInt(process.env.REACT_APP_COUNT_ELEMENT_IN_PAGE);
  var page = new SearchPage(countElementsInPage, 1);
  var url = request(page);
  return <>
    <p>{url}</p>
  </>
}

export default App;
