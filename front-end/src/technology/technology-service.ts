import { observable } from "mobx";
import RequestBuilder from "../base/request-builder";
import { Technology } from "./models/technology";

export const LoadTechs = async () => {
    const requestBuilder = new RequestBuilder("GET",
     "https://localhost:50001/api/","Technology");

    State.technologies = await requestBuilder.GetResultAsync<Technology[]>();
}

export const GetTechs = async () => {
    if(State.technologies == null)
        await LoadTechs();

    return State.technologies;
};

export const State = observable<IState>({
    technologies : []
});

interface IState {
    technologies : Technology[]
}