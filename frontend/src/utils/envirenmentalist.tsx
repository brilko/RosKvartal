export default function tryGetEnvAsString(envConstant: string|undefined) {
    if(envConstant === undefined)
        throw new Error();
    return envConstant;
}

export function tryGetEnvAsInt(envConstant: string|undefined) {
    envConstant = tryGetEnvAsString(envConstant);
    return Number.parseInt(envConstant);
}