export interface IPageSlider {
    setNumber: (newNumber: number) => void;
    currentNumber: number;
}

export function PageSlider({setNumber, currentNumber}: IPageSlider) {
  return <>
    <button disabled={currentNumber <= 1} style={{display: "inline"}} onClick={() => setNumber(currentNumber - 1) }>
        <img src="LeftArrow.png" alt="Предыдущая" />
    </button>
    <Dots pageNumber={currentNumber}/>
    <AnotherPage setNumber={setNumber} anotherNumber={currentNumber - 2}/>
    <AnotherPage setNumber={setNumber} anotherNumber={currentNumber - 1}/>
    <p style={{display: "inline", margin:"6px", fontSize:"20px"}}> {currentNumber} </p>
    <AnotherPage setNumber={setNumber} anotherNumber={currentNumber + 1}/>
    <AnotherPage setNumber={setNumber} anotherNumber={currentNumber + 2}/>
    <Dots pageNumber={undefined}/>
    <button style={{display: "inline"}} onClick={() => setNumber(currentNumber + 1)}>
        <img src="RightArrow.png" alt="Следующая" />
    </button>
  </>
}

interface IDots {
    pageNumber: number | undefined
}

function Dots({pageNumber} : IDots) {
    return <>
        {pageNumber !== undefined && pageNumber <= 3 ? <></> : <p style={{display: "inline"}}> ... </p>}
    </>
}

interface IAnotherPage {
    setNumber: (newNumber: number) => void;
    anotherNumber: number;
}

function AnotherPage({setNumber, anotherNumber}: IAnotherPage) {
    return <>
    {anotherNumber <= 0 ? <></> : 
        <p onClick={() => setNumber(anotherNumber)} style={{display: "inline", margin:"4px"}}> 
            {anotherNumber} 
        </p>} 
    </>
}

