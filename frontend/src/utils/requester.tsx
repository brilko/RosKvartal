import React from 'react';
import tryGetEnvAsString from "./envirenmentalist";
import axios from 'axios';
import { Examination } from './Examination';
import { SearchPage } from './SearchPage';

export function request(page: SearchPage, setExamination: React.Dispatch<React.SetStateAction<Examination[]>>) {
    var url = constructUrlToExaminations(page);
    axios.get(url)
    .then(function(response){
        var examinations = response.data as Examination[]
        setExamination(examinations); 
    })
    .catch(reason => {
        console.log(reason)
    })
    .finally();
}  

function constructUrlToExaminations(page: SearchPage) {
    var urlBase = tryGetEnvAsString(process.env.REACT_APP_EXAMINATIONS_WEB_API);
    var pageSizeParameter = tryGetEnvAsString(process.env.REACT_APP_EXAMINATIONS_WEB_API_PAGE_SIZE_PARAMETER);
    var pageNumberParameter = tryGetEnvAsString(process.env.REACT_APP_EXAMINATIONS_WEB_API_PAGE_NUMBER_PARAMETER);
    var url = urlBase
        .replace(pageSizeParameter, page.size.toString())
        .replace(pageNumberParameter, page.number.toString());
    return url; 
}

