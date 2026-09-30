import { API_URL } from "@/libs/constants";

export interface MuscleGroup {
  id: number;
  name: string;
}

export async function getMuscleGroups(): Promise<MuscleGroup[]> {
  const response = await fetch(`${API_URL}/api/musclegroups`, {
    method: "GET",
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch muscle groups: ${response.status}`);
  }

  return (await response.json()) as MuscleGroup[];
}

export async function getMuscleGroupById(id: number): Promise<MuscleGroup> {
  const response = await fetch(`${API_URL}/api/musclegroups/${id}`, {
    method: "GET",
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch muscle group with id ${id}: ${response.status}`);
  }

  return (await response.json()) as MuscleGroup;
}   
