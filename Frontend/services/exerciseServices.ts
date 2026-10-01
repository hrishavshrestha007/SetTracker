import { API_URL } from "@/libs/constants";

export type MuscleGroup =
  | "Chest"
  | "Back"
  | "Legs"
  | "Arms"
  | "Shoulders"
  | "Core";

export interface Exercise {
  id: number;
  name: string;
  muscle: MuscleGroup;
  icon: string;
  color: string;
  bg: string;
  sets: number | null;
  reps: number | null;
}

export interface ExerciseSummary {
  id: number;
  name: string;
  muscle: MuscleGroup;
  icon: string;
  color: string;
  bg: string;
}

export async function getExercises(): Promise<ExerciseSummary[]> {
  const response = await fetch(`${API_URL}/api/exercises`, {
    method: "GET",
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch exercises: ${response.status}`);
  }

  const exercises = (await response.json()) as Exercise[];

  return exercises.map(
    ({ id, name, muscle, icon, color, bg }): ExerciseSummary => ({
      id,
      name,
      muscle,
      icon,
      color,
      bg,
    })
  );
}
export async function getExerciseById(id: number): Promise<Exercise> {
  const response = await fetch(`${API_URL}/api/exercises/${id}`, {
    method: "GET",
  });

  if (!response.ok) {
    throw new Error(`Failed to fetch exercise with id ${id}: ${response.status}`);
  }

  return (await response.json()) as Exercise;
}

export async function updateExerciseSetsReps(
  userId: number,
  id: number,
  sets: number,
  reps: number
): Promise<void> {
  const response = await fetch(`${API_URL}/api/user-exercises/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      userId,
      exerciseId: id,
      sets,
      reps,
    }),
  });

  if (!response.ok) {
    throw new Error(`Failed to save exercise with id ${id}: ${response.status}`);
  }
}